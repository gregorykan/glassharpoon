$(document).ready(function ()
{
	var map;
	var pointArray;
	var heatMap;
	var locations = [];

	var pusher = new Pusher('45c06fa98717fe603c5a');
	var channel = pusher.subscribe('tweetStream');
	channel.bind('tweetEvent', function (data) 
	{
		console.log(data);
		locations.push(new google.maps.LatLng(data["message"]["Latitude"], data["message"]["Longitude"]));
		fillMap(locations);
	});

	initialize();

	function fillMap(locations)
	{
		var pointArray = new google.maps.MVCArray(locations);
		heatMap.setData(pointArray);
	}

	function initialize ()
	{
		console.log ("initialize");
		var mapOptions = 
		{
			zoom: 1,
			center: new google.maps.LatLng(37.774546, -122.433523),
			mapTypeId: google.maps.MapTypeId.SATELLITE
		};

		map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
		var pointArray = new google.maps.MVCArray(locations);
		heatMap = new google.maps.visualization.HeatmapLayer(
		{
			data: pointArray
		});

		heatMap.setMap(map);
	}
});