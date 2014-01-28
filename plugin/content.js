var port = chrome.runtime.connect({});
var contentСontroller = new ContentController(port);

$(document).ready(function() {
	//var contentСontroller = new ContentController();
	
	contentСontroller.log('123');
	/*if ($('#signup_button').val() === undefined)
		contentСontroller.recognize();
	else
	{
		contentСontroller.signup();
	}*/
});