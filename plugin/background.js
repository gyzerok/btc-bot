setTimeout(close, 1000 * 60 * 10);

chrome.runtime.onMessage.addListener(
	function(request, sender, sendResponse) {
		type = request.type;
		
		if (type == 'close')
			chrome.tabs.remove(sender.tab.id, function() { });
		
		if (type == 'cookies')
			chrome.cookies.getAll({url: 'http://freebitco.in'}, function(cookies) { 
				sendResponse(cookies);
			});
		
		if (type == 'proxy')
			chrome.proxy.settings.get({}, function(config) {
				var host = config.value.rules.singleProxy.host;
				var port = config.value.rules.singleProxy.port;
				var proxy = host + ':' + port;
				
				$.ajax({
					url: serverURL,
					type: 'post',
					data: { type: 'log', proxy: proxy }
				});
			});
});

function close()
{
	chrome.tabs.query({active: true}, function(tabs) {
		chrome.tabs.remove(tabs[0].id, function() { });
	});
}

BackController = function()
{
	this.serverURL = 'http://127.0.0.1';
}

BackController.prototype.send = function(data, callback)
{
	$.ajax({
		url: this.serverURL,
		type: 'post',
		data: data,
		context: this,
		success: callback
	});
}

BackController.prototype.close = function()
{
	chrome.tabs.query({active: true}, function(tabs) {
		chrome.tabs.remove(tabs[0].id, function() { });
	});
}