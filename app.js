$(document).ready(function ()
{
	var map;
	var pointArray;
	var heatMap;
	var locations = [];
	var geocoder = new google.maps.Geocoder();
	var pusher = new Pusher('45c06fa98717fe603c5a');
	var channel = pusher.subscribe('tweetStream');
	var place;
	var myLatlng;

	channel.bind('tweetEvent', function (data) 
	{
		addCoords(data["message"]["Latitude"], data["message"]["Longitude"]);
		fillMap(locations);
	});

	channel.bind('tweetEventWithPlace', function (data)
	{
		geocode(data["message"]["Place"]);
	});

	initialize();

	function geocode(place)
	{
		// geocoder.geocode({ address: place }, function(results, status)
		// {
		// 	console.log(place);
		// 	if (status == google.maps.GeocoderStatus.OK)
		// 	{
		// 		var loc = results[0].geometry.location;
		// 		addCoords(loc.lat(), loc.lat());
		// 	}
		// })
		var input = place;
		$.ajax(
		{
			url: "https://maps.googleapis.com/maps/api/geocode/json?address=" + input,
			method: "GET",
		}).done(function (data)
		{
			var jsonReturn = data["results"];
			var lat = jsonReturn[0]["geometry"]["location"]["lat"];
			var lng = jsonReturn[0]["geometry"]["location"]["lng"];
		addCoords(lat, lng);
		});
	}

	function addCoords (lat, lng)
	{
		locations.push(new google.maps.LatLng(lat, lng));
		myLatlng = new google.maps.LatLng(lat, lng);
		var marker = new google.maps.Marker({
			position: myLatlng
		});
		marker.setMap(map);
		fillMap(locations);
	}

	function fillMap(locations)
	{
		var pointArray = new google.maps.MVCArray(locations);
		heatMap.setData(pointArray);

	}

	function initialize ()
	{
		
		var mapOptions = 
		{
			zoom: 2,
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