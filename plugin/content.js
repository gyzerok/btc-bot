var port = chrome.runtime.connect({});
var contentСontroller = new ContentController(port);

$(document).ready(function() {
	contentСontroller.log('123');
	/*if ($('#signup_button').val() === undefined)
		contentСontroller.recognize();
	else
	{
		contentСontroller.signup();
	}*/
});