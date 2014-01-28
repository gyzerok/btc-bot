var self;

BackController = function() {
	self = this;
	self.serverURL = 'http://127.0.0.1';
}

BackController.prototype.log = function(text) {
	self.getProxy(function (proxy) {		
		var logText = proxy + " " + text;
		self.send({type: 'log', text: logText}, function() {});
		/*self.getAddress(function (address, context) {
			var logText = proxy + " " + address + " " + text;
			self.send({type: 'log', text: logText}, function() {});
		});*/
	});
}

BackController.prototype.getAddress = function(callback) {
	chrome.cookies.getAll({domain: 'freebito.in', name: 'btc_address'}, function(cookies) {
		// some code here later
	});
}

BackController.prototype.getProxy = function(callback) {
	chrome.proxy.settings.get({}, function(config) {
		var proxy = config.value.mode;//.rules.singleProxy.host;
		callback(proxy);
	});
}

BackController.prototype.send = function(data, callback) {
	$.ajax({
		url: self.serverURL,
		type: 'post',
		data: data,
		context: self,
		success: callback
	});
}

BackController.prototype.close = function() {
	chrome.tabs.query({active: true}, function(tabs) {
		chrome.tabs.remove(tabs[0].id, function() { });
	});
}