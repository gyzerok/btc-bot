BackController = function() {
	this.serverURL = 'http://127.0.0.1';
}

BackController.prototype.log = function(text) {
	this.getProxy(function (proxy, context) {		
		context.getAddress(function (address, context) {
			var logText = proxy + " " + address + " " + text;
			alert(logText);
			context.send({type: 'log', text: logText}, function() {});
		}, context);
	}, this);
}

BackController.prototype.getAddress = function(callback, context) {
	chrome.cookies.getAll({domain: 'freebitco.in'}, function(cookies) {
		alert(JSON.stringify(cookies));
		callback('siski', context);
		/*for (var i = 0; i < cookies.length; i++)
			if (cookies[i].name == 'btc_address')
				callback(cookies[i].value, context);*/
	});
}

BackController.prototype.getProxy = function(callback, context) {
	chrome.proxy.settings.get({}, function(config) {
		var proxy = config.value.mode;//rules.singleProxy.hostname;
		callback(proxy, context);
	});
}

BackController.prototype.send = function(data, callback) {
	$.ajax({
		url: this.serverURL,
		type: 'post',
		data: data,
		context: this,
		success: callback
	});
}

BackController.prototype.close = function() {
	chrome.tabs.query({active: true}, function(tabs) {
		chrome.tabs.remove(tabs[0].id, function() { });
	});
}