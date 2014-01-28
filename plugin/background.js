var backController = new BackController();

setTimeout(backController.close, 1000 * 60 * 5);

chrome.runtime.onConnect.addListener(function(port) {
	port.onMessage.addListener(function(msg) {
		switch(msg.type)
		{
			case 'log':
				backController.log(msg.text);
				break;
			case 'close':
				backController.close();
				break;
		}
	});
});