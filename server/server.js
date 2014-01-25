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
		case 'signup':
			signup(res);
			break;
		case 'recognize':
			recognize(res, req.body.url);
			break;
		case 'log':
			log(res, req.body.proxy);
			break;
	}
	
});
app.listen(80);
console.log('Server is running...');

function recognize(res, url)
{
	var ag = new Antigate('2e7f6789c66db87a70df90c0f821206d');
	
	ag.processFromURL(url, function(error, text, id) {
		if (error)
			throw error;
		else
		{
			res.writeHead(200, {'Content-Type': 'text/html'});
			res.end(text);
		}
	});
}

function signup(res)
{
	if (credentials.length > 0 && index < credentials.length)
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

function log(res, proxy)
{
	console.log('Working proxy: ' + proxy);
	fs.appendFileSync('log.txt', proxy, encoding='utf8');
	
	res.writeHead(200, {'Content-Type': 'text/html'});
	res.end();
}