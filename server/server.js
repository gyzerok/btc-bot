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
		case 'recognize':
			recognize(res, req.body.url);
			break;
		case 'log':
			log(res, req.body.text);
			break;
		case 'signup':
			signup(res);
			break;
	}
	
});
app.listen(80);
console.log('Server is running...');

function recognize(res, url)
{
	var ag = new Antigate('2e7f6789c66db87a70df90c0f821206d');
	
	res.writeHead(200, {'Content-Type': 'text/html'});
	ag.processFromURL(url, function(error, text, id) {
		if (error)
			res.end('i love captcha');
		else
			res.end(text);
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

function log(res, text)
{
	var date = new Date();
	var dateStr = date.getDay() + '.' + date.getMonth() + '.' + date.getFullYear();
	var timeStr = date.toLocaleTimeString();
	text = dateStr + ' ' + timeStr + '|' + text + '\n';
	
	console.log(text);
	
	fs.appendFileSync('log.txt', text, encoding='utf8');
	
	res.writeHead(200);
	res.end();
}