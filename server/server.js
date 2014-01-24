var express = require('express');
var Antigate = require('antigate');

var ag = new Antigate('2e7f6789c66db87a70df90c0f821206d');
var app = express();
app.use(express.bodyParser());

app.post('/', function(req, res){
	ag.processFromURL(req.body.url, function(error, text, id) {
		if (error)
			throw error;
		else
		{
			console.log(text);
			res.writeHead(200, {'Content-Type': 'text/html'});
			res.end(text);
		}
	});
});

app.listen(80);
console.log('Server running at http://127.0.0.1:80/');