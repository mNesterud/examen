function startTime() {
    var d = new Date();
    sessionStorage.setItem("StartTime", JSON.stringify(d));
}

function responseTime() {
    var start = new Date(JSON.parse(sessionStorage.getItem("StartTime")));
    var current = new Date()
    var time = current - start;
    return time;
}
function underlineQ(currentID) {
    var lastMCId = JSON.parse(sessionStorage.getItem("lastMCId"));
    if (currentID == lastMCId) {
        $('#qText').addClass("last_mc_underline");
    }
}

function killSession() {
    $.ajax({
        type: 'POST',
        url: '/Questionnaire/KillSession/',
        success: function (result) {
            
        }
    });
}
function preKillSession() {
    $.ajax({
        type: 'POST',
        url: '/Start/PreKillSession/',
        success: function (result) {

        }
    });
}
//function preventUnload() {
//    window.addEventListener("onbeforeunload", function () {
//        return "uppdatering är låst";
//    });
//}

function getBrowserType() {

    var userBrowser = "";
    var agent = "Other";

    if (navigator.userAgent != null)
    {
        agent = navigator.userAgent;

        if (agent.indexOf("Edge") > -1) {
            userBrowser = "Edge";
        }
        else if (agent.indexOf("Chrome") > -1) {
            userBrowser = "Chrome";
        }
        else if (agent.indexOf("Safari") > -1) {
            userBrowser = "Safari";
        }
        else if (agent.indexOf("Opera") > -1) {
            userBrowser = "Opera";
        }
        else if (agent.indexOf("Firefox") > -1) {
            userBrowser = "Firefox";
        }
        else if (agent.indexOf("MSIE") > -1) {
            userBrowser = "Internet Explorer";
        }
        else if (agent.indexOf("Trident") > -1) {
            userBrowser = "Internet Explorer";
        }
        userBrowser += " - " + agent;
    }
    else {
        userBrowser = "Other";
    }
    
    return userBrowser;
}
