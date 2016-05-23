// View Model for Confirmation
var ist = window.ist || {};
ist.confirmationDialog = {
    viewModel: (function () {

        // Local Variables
        var onProceed, onCancel, element = $("#dialog-confirm"),

        // Show Dialog
        show = function (callbacks) {
            if (callbacks) {
                onProceed = callbacks.onProceed;
                onCancel = callbacks.onCancel;
            }

            if (!element) {
                throw error("Container not defined!");
            }
            
            // Show Dialog
            element.modal('show');
        },
            
        // Hide Dialog
        hide = function () {
            element.modal('hide');
        };

        // Proceed
        $("#dialog-confirm-yes").click(function (e) {
            hide();
            if (onProceed && typeof onProceed === "function") {
                onProceed();
            }
            e.preventDefault();
        });

        // Cancel
        $("#dialog-confirm-no").click(function (e) {
            hide();
            if (onCancel && typeof onCancel === "function") {
                onCancel();
            }
            e.preventDefault();
        });

        return {
            show: show,
            hide: hide
        };

    })()
};
