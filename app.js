$(document).ready(function (){
	var pusher = new Pusher('45c06fa98717fe603c5a');
	var channel = pusher.subscribe('tweetStream');
	channel.bind('tweetEvent', function (data) {
		console.log(data);

	});


});