var express = require('express');
var Antigate = require('antigate');
var fs = require('fs');

var credentials = JSON.parse(fs.readFileSync('./credentials.json', 'utf8'));
var index = 0;

var app = express();
app.use(express.bodyParser());

app.post('/', function(req, res) {
	switch (req.body.type)
	{
		'signup':
			signup(res);
			break;
		'recognize':
			recognize(res, req.body.url);
			break;
	}
	
});
app.listen(80);
console.log('Server running at http://127.0.0.1:80/');

function recognize(url)
{
	var ag = new Antigate('2e7f6789c66db87a70df90c0f821206d');
	
	ag.processFromURL(url, function(error, text, id) {
		if (error)
			throw error;
		else
		{
			console.log(text);
			res.writeHead(200, {'Content-Type': 'text/html'});
			res.end(text);
		}
	});
}

function signup()
{
	if (credentials.length > 0 && index < credentials.kength)
	{
		res.writeHead(200, {'Content-Type': 'text/html'});
		res.end(credentials[index]);
		index++;
	}
	else
	{
		res.writeHead(500);
		res.end();
	}
}