ContentController = function(bus)
{
	this.serverURL = 'http://127.0.0.1';
	this.password = "KLjdfnfaduU325";
	this.bus = bus;
}

ContentController.BACKGROUND = 0;
ContentController.SERVER 	 = 1;

ContentController.prototype.recognize = function()
{
	var captchaURL = $('#recaptcha_image img:first-child:visible').attr('src');
	
	if (captchaURL !== undefined)
	{
		this.send(
			ContentController.SERVER,
			{type: 'recognize', url: captchaURL},
			function(text)
			{
				console.log(text);
	
				if (text == 'ERROR_CAPTCHA_UNSOLVABLE')
					$('small').click();
				else
				{
					$('#recaptcha_response_field').val(text);
					$('#free_play_form_button').click();
				}
				
				setTimeout(this.recognize, 5000);
			}
		);
	}
	else
	{
		profit = $('#winnings').html();
		
		if (profit !== undefined)
			this.log(profit);
		else
			setTimeout(this.close, 5000);
	}
}

ContentController.prototype.signup = function()
{
	this.send(
		ContentController.SERVER,
		{type: 'signup'},
		function(btc_address)
		{
			$('#signup_form_btc_address').val(btc_address);
			$('#signup_form_password').val(this.password);
			$('#signup_form_repeat_password').val(this.password);
			$('#signup_button').click();
		}
	);
}

ContentController.prototype.log = function(text) {
	this.send(ContentController.BACKGROUND, {type: 'log', text: text});
}

ContentController.prototype.close = function()
{
	this.send(ContentController.BACKGROUND, {type: 'close'});
}

ContentController.prototype.send = function(dest, data, callback)
{
	switch (dest)
	{
		case ContentController.BACKGROUND:
			this.bus.postMessage(data);
			break;
		case ContentController.SERVER:
			$.ajax({
				url: this.serverURL,
				type: 'post',
				data: data,
				context: this,
				success: callback
			});
			break;
	}
}