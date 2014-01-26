$(document).ready(function() {
	var controller = new ContentController();
	
	if ($('#signup_button').val() === undefined)
		controller.recognize();
	else
	{
		controller.signup();
	}
});