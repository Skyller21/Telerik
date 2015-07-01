function isBrowserMozilla() {
    var myWindow = window,
        //All modern browsers returns "Mozilla", for compatibility reasons.
        browser = myWindow.navigator.appCodeName,
        isMozilla = (browser == "Mozilla");

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}