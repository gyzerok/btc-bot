var self;

ContentController = function(bus)
{
	self = this;
	self.serverURL = 'http://127.0.0.1';
	self.password = "KLjdfnfaduU325";
	self.bus = bus;
}

ContentController.BACKGROUND = 0;
ContentController.SERVER 	 = 1;

ContentController.prototype.recognize = function()
{
	var captchaURL = $('#recaptcha_image img:first-child:visible').attr('src');
	
	if (captchaURL !== undefined)
	{
		self.send(
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
				
				setTimeout(self.recognize, 5000);
			}
		);
	}
	else
	{
		profit = $('#winnings').html();
		
		if (profit !== undefined)
			self.log(profit);
		else
			setTimeout(self.close, 30000);
	}
}

ContentController.prototype.signup = function()
{
	self.send(
		ContentController.SERVER,
		{type: 'signup'},
		function(btc_address)
		{
			$('#signup_form_btc_address').val(btc_address);
			$('#signup_form_password').val(self.password);
			$('#signup_form_repeat_password').val(self.password);
			$('#signup_button').click();
		}
	);
}

ContentController.prototype.log = function(text) {
	self.send(ContentController.BACKGROUND, {type: 'log', text: text});
}

ContentController.prototype.close = function()
{
	self.send(ContentController.BACKGROUND, {type: 'close'});
}

ContentController.prototype.send = function(dest, data, callback)
{
	switch (dest)
	{
		case ContentController.BACKGROUND:
			self.bus.postMessage(data);
			break;
		case ContentController.SERVER:
			$.ajax({
				url: self.serverURL,
				type: 'post',
				data: data,
				context: self,
				success: callback
			});
			break;
	}
}