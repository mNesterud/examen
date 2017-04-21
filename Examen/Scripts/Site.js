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