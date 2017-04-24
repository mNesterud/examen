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

function killSession() {
    $.ajax({
        type: 'POST',
        url: '/Questionnaire/KillSession/',
        success: function (result) {
            
        }
    });
}
function preventUnload() {
    window.addEventListener("onbeforeunload", function () {
        return "uppdatering är låst";
    });
}

function getBrowserType() {
    var agent = navigator.userAgent;
    var userBrowser = "";

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

    userBrowser += " - " + agent
    return userBrowser;
}
