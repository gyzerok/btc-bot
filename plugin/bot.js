var contentСontroller = new ContentController();

var port = chrome.runtime.connect({});
port.onMessage.addListener(function(msg) {
	if (msg.question == "Who's there?")
		port.postMessage({answer: "Madame"});
	else if (msg.question == "Madame who?")
		port.postMessage({answer: "Madame... Bovary"});
});

$(document).ready(function() {
	var contentСontroller = new ContentController();
	
	if ($('#signup_button').val() === undefined)
		contentСontroller.recognize();
	else
	{
		contentСontroller.signup();
	}
});