$(document).ready(function() {
	var credentials = '';
	
	if ($("#signup_button").val() === undefined)
		recognize();
	else
	{
		$.getJSON(chrome.extension.getURL('./credentials.json'), function(data) {
			signup(data.btc_address, data.btc_password);
		});
	}
});

function signup(btc_address, btc_password)
{
	$("#signup_form_btc_address").val(btc_address);
	$('#signup_form_password').val(btc_password);
	$('#signup_form_repeat_password').val(btc_password);
	
	$("#signup_button").click();
}

function recognize()
{
	var captchaURL = $("#recaptcha_image img:first-child:visible").attr("src");
	
	if (captchaURL !== undefined)
	{
		$.ajax({
			url: "http://127.0.0.1",
			type: "post",
			data: { url: captchaURL },
			success: onCaptchaReady
		});
	}
	else
		setTimeout(close, 5000);
}

function onCaptchaReady(text)
{
	console.log(text);
	
	$("#recaptcha_response_field").val(text);
	$("#free_play_form_button").click();
	
	setTimeout(recognize, 5000);
}

function close()
{
	chrome.runtime.sendMessage({type: 'close'});
}