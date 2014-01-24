chrome.runtime.onMessage.addListener(
	function(request, sender, sendResponse) {
		type = request.type;
		
		if (type == 'close')
			chrome.tabs.query({active: true}, function(tabs) {
				chrome.tabs.remove(tabs[0].id, function() { });
			});
		
		if (type == 'cookies')
			chrome.cookies.getAll({url: 'http://freebitco.in'}, function(cookies) { 
				sendResponse(cookies);
			});
});