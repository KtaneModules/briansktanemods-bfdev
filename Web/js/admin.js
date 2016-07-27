var computer1IP = "";
var computer2IP = "";

function startMission()
{
	var missionId = $("#missionId").val();
	var seed = $("#seed").val();
	computer1IP = $("#computer1IP").val();
	computer2IP = $("#computer2IP").val();
	if(computer1IP != "")
	{
		$.ajax({
		  url: "http://" + computer1IP + "/startMission?missionId=" + missionId + "&seed=" + seed
		}).done(function(data) {
			startPolling(1);
		});
	}
	
	if(computer2IP != "")
	{
		$.ajax({
		  url: "http://" + computer2IP + "/startMission?missionId=" + missionId + "&seed=" + seed
		}).done(function(data) {
			startPolling(2);
		});
	}
}

function startPolling(num)
{
	setTimeout(
		function()
		{
			var ip = $("#computer" + num + "IP").val();
			$.ajax({
			  url: "http://" + ip + "/bombInfo"
			}).done(function(data) {
				$("#bombInfo" + num).html(data);
				startPolling(num);
			});
		},
		1000
	);
}


$(document).ready(function(){
	$("#startMission").click(startMission);
});