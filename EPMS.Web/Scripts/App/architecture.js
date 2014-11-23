//
// Busy Indicator
var spinnerVisibleCounter = 0;

// Show Busy Indicator
function showProgress() {
    ++spinnerVisibleCounter;
    if (spinnerVisibleCounter > 0) {
        $("div#spinner").fadeIn("fast");
    }
};

// Hide Busy Indicator
function hideProgress() {
    --spinnerVisibleCounter;
    if (spinnerVisibleCounter <= 0) {
        spinnerVisibleCounter = 0;
        var spinner = $("div#spinner");
        spinner.stop();
        spinner.fadeOut("fast");
    }
};

//show toast on new item created or updated based on url parameter
$(function () {

    var messageVm = $("#Message").val();
    if ($("#IsSaved").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.success(messageVm);
        }
    }
    else if ($("#IsUpdated").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.success(messageVm);
        }
    }
    else if ($("#IsError").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.error(messageVm);
        }
    }
    else {

    }

    $("#Message").val('');
});
// A