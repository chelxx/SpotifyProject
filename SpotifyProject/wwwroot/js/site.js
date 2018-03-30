// Write your Javascript code.
// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal 
btn.onclick = function() {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


var status = 0;
function Play(music,id) {
    var audio = $("#"+id); 
	if(status == 0 || status == 2)
	{     
		if(status == 0) audio.attr("src", music);
		audio[0].play();
		$("#play").attr("class","glyphicon glyphicon-pause aligned")
		status = 1;
	} else if(status == 1) {    
		audio[0].pause();
		$("#play").attr("class","glyphicon glyphicon-play aligned")
		status = 2;
	}
}
function Stop(music,id) {
	var audio = $("#"+id);
	audio.attr("src", '');
	$("#play").attr("class","glyphicon glyphicon-play aligned")
	status = 0;
}
function Restart(music,id) {
	var audio = $("#"+id);
	audio.prop("currentTime",0)
}
function VolumeUp(music,id) {
	var audio = $("#"+id);
	var volume = $("#"+id).prop("volume")+0.1;
	if(volume > 1) volume = 1;
    $("#"+id).prop("volume",volume);
}
function VolumeDown(music,id) {
	var audio = $("#"+id);
	var volume = $("#"+id).prop("volume")-0.1;
	if(volume < 0) volume = 0;
    $("#"+id).prop("volume",volume);
}
function Forward5(music,id) {
	var audio = $("#"+id);
	audio.prop("currentTime",audio.prop("currentTime")+5);
}
function Backward5(music,id) {
	var audio = $("#"+id);
	audio.prop("currentTime",audio.prop("currentTime")-5);
}
function Forward1(music,id) {
	var audio = $("#"+id);
	audio.prop("currentTime",audio.prop("currentTime")+1);
}
function Backward1(music,id) {
	var audio = $("#"+id);
	audio.prop("currentTime",audio.prop("currentTime")-1);
}


$(document).ready(function(){
	// TOP 20 TRACKS - OVERVIEW
    $.get('http://ws.audioscrobbler.com/2.0/?method=chart.gettoptracks&&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
		var toprow = "";
		for (var i = 0; i < 20; i++)
		{
			toprow += "<tr>";
			toprow += "<td><h4 class='needborder'><a href=''>" + (i+1) + "</a></h4></td>";
			toprow += "<td><h4 class='needborder'><a href=''>" + res.tracks.track[i]["name"] + "</a></h4></td>";
			toprow += "<td><h4 class='needborder'><a href=''>" + res.tracks.track[i]["artist"]["name"] + "</a></h4></td>";
			toprow += "<td><h4 class='needborder'><a href=''>" + res.tracks.track[i]["playcount"] + "</a></h4></td>";
			toprow += "<td><h4 class='needborder'><a href=''>Add to Playlist</a></h4></td>";
			toprow += "</tr>";
		}
		$('tbody#tbodyoverview').html(toprow);
    }, 'json');
	// END OF TOP 20 TRACKS - OVERVIEW

	// TOP 50 TRACKS IN USA - CHARTS
    $.get('http://ws.audioscrobbler.com/2.0/?method=geo.gettoptracks&country=canada&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
		var top50row = "";
		for (var i = 0; i < 50; i++)
		{
			top50row += "<tr>";
			top50row += "<td><h4 class='needborder'><a href=''>" + (i+1) + "</a></h4></td>";
			top50row += "<td><h4 class='needborder'><a href=''>" + res.tracks.track[i]["name"] + "</a></h4></td>";
			top50row += "<td><h4 class='needborder'><a href=''>" + res.tracks.track[i]["artist"]["name"] + "</a></h4></td>";
			top50row += "<td><h4 class='needborder'><a href=''>Follow Me</a></h4></td>";
			top50row += "</tr>";
		}
		$('tbody#tbodychart').html(top50row);
    }, 'json');
	// END OF TOP 50 TRACKS IN USA - CHARTS

	// ARTISTS
    $.get('http://ws.audioscrobbler.com/2.0/?method=chart.gettopartists&&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
		var topartistrow1 = "";
		var topartistrow2 = "";
		for (var i = 0; i < 5; i++)
		{
			topartistrow1 += "<img src='" + res.artists.artist[i]["image"][3]["#text"] + "' class='artistpage' id='" + res.artists.artist[i]["mbid"] + "'>";
		}
		for (var i = 6; i < 11; i++)
		{
			topartistrow2 += "<img src='" + res.artists.artist[i]["image"][3]["#text"] + "' class='artistpage'  id='" + res.artists.artist[i]["mbid"] + "'>";
		}
		$('div#artist1').html(topartistrow1);
		$('div#artist2').html(topartistrow2);
    }, 'json');
	// END OF ARTISTS

	// ARTISTS INFO
	$('body').on('click','img',function(){
		var id = $(this).attr("id")
		$.get('http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&mbid=' + id + '&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
			var artistinfo = "";
			artistinfo += "<h2 class='play'>Artist: " + res.artist.name + "</h2>";
			artistinfo += "<h3 class='bio's>BIOGRAPHY: " + res.artist.bio.content + "</h3>";
			
			$('div#artistinfo').html(artistinfo);
		}, 'json');
	});
	// END OF ARTISTS INFO

	// SEARCH FOR TRACK
    $('button#searchtrack').click('submit', function() {
        var track = $('form').find('input[name="track"]').val();
        $.get('http://ws.audioscrobbler.com/2.0/?method=track.search&track=' + track + '&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
			var trackrow = "";
			var trackroww = "";
			for(var i = 0; i < 1; i++)
			{
				trackroww += "<tr>";
				trackroww += "<td>ART</td>";
				trackroww += "<td>TRACK</td>";
				trackroww += "<td>ARTIST</td>";
				trackroww += "</tr>";
			}
            for(var i = 0; i < 20; i++)
            {
				trackrow += "<tr>";
				trackrow += "<td><img src='" + res.results.trackmatches.track[i]["image"][3]["#text"] + "' class='roundme'></td>";
				trackrow += "<td><h4 class='needborder'><a href=''>" + res.results.trackmatches.track[i]["name"] + "</a></h4></td>";
				trackrow += "<td><h4 class='needborder'><a href=''>" + res.results.trackmatches.track[i]["artist"] + "</a></h4></td>";
				trackrow += "</tr>";
            }
			$('thead#theadsearch').html(trackroww);
			$('tbody#tbodysearch').html(trackrow);
		}, 'json');
		return false;
	});
	// END OF SEARCH FOR TRACK
	
	// SEARCH FOR ARTIST
    $('button#searchartist').click('submit', function() {
        var artist = $('form').find('input[name="artist"]').val();
        $.get('http://ws.audioscrobbler.com/2.0/?method=artist.search&artist=' + artist + '&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
			var artistroww = "";
			var artistrow = "";
			for(var i = 0; i < 1; i++)
			{
				trackroww += "<tr>";
				trackroww += "<td>ART</td>";
				trackroww += "<td>ARTIST</td>";
				trackroww += "</tr>";
			}
            for(var i = 0; i < 20; i++)
            {
				artistrow += "<tr>";
				artistrow += "<td><img src='" + res.results.artistmatches.artist[i]["image"][3]["#text"] + "' class='roundme'></td>";
				artistrow += "<td><h4 class='needborder'><a href=''>" + res.results.artistmatches.artist[i]["name"] + "</a></h4></td>";
				artistrow += "</tr>";
            }
			$('thead#theadsearch').html(trackroww);
			$('tbody#tbodysearch').html(trackrow);
		}, 'json');
		return false;
	});
	// END OF SEARCH FOR ARTIST


	// SEARCH FOR ALBUM
	$('button#searchalbum').click('submit', function() {
        var banana = $('form').find('input[name="album"]').val();
        $.get('http://ws.audioscrobbler.com/2.0/?method=album.search&album=' + banana + '&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
			var ban = "";
			var trackroww = "";
			for(var i = 0; i < 1; i++)
			{
				trackroww += "<tr>";
				trackroww += "<td>ART</td>";
				trackroww += "<td>ALBUM</td>";
				trackroww += "<td>ARTIST</td>";
				trackroww += "</tr>";
			}
            for(var i = 0; i < 20; i++)
            {
				ban += "<tr>";
				ban += "<td><img src='" + res.results.albummatches.album[i]["image"][3]["#text"] + "' class='roundmealbum'></td>";
				ban += "<td><h4 class='needborder'><a href=''>" + res.results.albummatches.album[i]["name"] + "</a></h4></td>";
				ban += "<td><h4 class='needborder'><a href=''>" + res.results.albummatches.album[i]["artist"] + "</a></h4></td>";				
				ban += "</tr>";
			}
			$('thead#theadsearch').html(trackroww);			
			$('tbody#tbodysearch').html(ban);			
        }, 'json');
        return false;
    });
	// END OF SEARCH FOR ALBUM



}) // END OF DOCUMENT.READY