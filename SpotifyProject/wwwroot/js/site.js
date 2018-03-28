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

	// function makeid() {
	// 	var text = "";
	// 	var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
	// 	for (var i = 0; i < 30; i++)
	// 	  text += possible.charAt(Math.floor(Math.random() * possible.length));
	// 	return text;
	// }

	// TOP 20 TRACKS - OVERVIEW
    var id = this.id;
    $.get('http://ws.audioscrobbler.com/2.0/?method=chart.gettoptracks&&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
		var topsongrank = "";
        var topsong = "";
		var topsongartist = "";
		var topsongplaycount= "";
		var addtoplaylist = "";
        for (var i = 0; i < 20; i++){
			topsongrank += "<h4 class='needborder'><a href=''>" + (i+1) + "</a></h4>";
			
			if(res.tracks.track[i]["artist"]["mbid"] == "" || res.tracks.track[i]["artist"]["mbid"] == null)
			{
				topsong += "<h4 class='needborder'>" + res.tracks.track[i]["name"] + "</h4>";
				addtoplaylist += "<h4 class='needborder'> - </h4>";
			}
			else
			{
				topsong += "<h4 class='needborder'><a href='" + res.tracks.track[i]["artist"]["mbid"] + "'>" + res.tracks.track[i]["name"] + "</a></h4>";
				addtoplaylist += "<h4 class='needborder'><a href='/addtoplaylist'>Add to Playlist</a></h4>";
			}
			
			topsongartist += "<h4 class='needborder'><a href=''>" + res.tracks.track[i]["artist"]["name"] + "</a></h4>";
			topsongplaycount += "<h4 class='needborder'><a href=''>" + res.tracks.track[i]["playcount"] + "</a></h4>";
		}
		$('td#topsongrank').html(topsongrank);
        $('td#topsong').html(topsong);
		$('td#topsongartist').html(topsongartist);
		$('td#topsongplaycount').html(topsongplaycount);
		$('td#addtoplaylist').html(addtoplaylist);
    }, 'json');
	// END OF TOP 20 TRACKS - OVERVIEW

	// TOP 50 TRACKS IN USA - CHARTS
	// NOTES: URL WILL NOT RECOGNIZE usa AS A COUNTRY PARAM??? I USED JAPAN LOL
    var id = this.id;
    $.get('http://ws.audioscrobbler.com/2.0/?method=geo.gettoptracks&country=japan&api_key=b2b8f8bedc83ccbdd65af6d8a83d7ffc&format=json', function(res) {
		var top50songrank = "";
        var top50song = "";
		var top50songartist = "";
		var top50songlink = "";
        for (var i = 0; i < 50; i++){
			top50songrank += "<h4 class='needborder'><a href=''>" + (i+1) + "</a></h4>";
			top50song += "<h4 class='needborder'><a href=''>" + res.tracks.track[i]["name"] + "</a></h4>";
			top50songartist += "<h4 class='needborder'><a href=''>" + res.tracks.track[i]["artist"]["name"] + "</a></h4>";
			top50songlink += "<h4 class='needborder'><a href='" + res.tracks.track[i]["url"] + "'>Follow Me</a></h4>";
		}
		$('td#top50songrank').html(top50songrank);
        $('td#top50song').html(top50song);
		$('td#top50songartist').html(top50songartist);
		$('td#top50songlink').html(top50songlink);
    }, 'json');
	// END OF TOP 50 TRACKS IN USA - CHARTS

}) // END OF DOCUMENT.READY



