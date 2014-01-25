//var serverURL = 'http://127.0.0.1';
var serverURL = "http://78.139.234.190";

$(document).ready(function() {
	chrome.runtime.sendMessage({type: 'proxy'});
	
	if ($('#signup_button').val() === undefined)
		recognize();
	else
	{
		signup();
	}
});

function signup()
{
	$.ajax({
		url: serverURL,
		type: 'post',
		data: { type: 'signup' },
		success: onSignUpReady
	});
}

function onSignUpReady(btc_address)
{
	var btc_password = "KLjdfnfaduU325";
	
	$('#signup_form_btc_address').val(btc_address);
	$('#signup_form_password').val(btc_password);
	$('#signup_form_repeat_password').val(btc_password);
	
	$('#signup_button').click();
}

function recognize()
{
	var captchaURL = $('#recaptcha_image img:first-child:visible').attr('src');
	
	if (captchaURL !== undefined)
	{
		var host = config.value.rules.singleProxy.host;
		var port = config.value.rules.singleProxy.port;
		var proxy = host + ':' + port;
		
		$.ajax({
			url: serverURL,
			type: 'post',
			data: { type: 'recognize', proxy: proxy },
		});
	}
	else
		setTimeout(close, 5000);
}

function onCaptchaReady(text)
{
	console.log(text);
	
	if (text == 'ERROR_CAPTCHA_UNSOLVABLE')
		$('small').click();
	else
	{
		$('#recaptcha_response_field').val(text);
		$('#free_play_form_button').click();
	}
	
	setTimeout(recognize, 5000);
}

function close()
{
	chrome.runtime.sendMessage({type: 'close'});
}