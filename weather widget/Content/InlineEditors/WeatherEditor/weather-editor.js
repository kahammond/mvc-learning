(function () {
    // Registers the 'number-editor' inline property editor within the page builder scripts
    window.kentico.pageBuilder.registerInlineEditor("weather-editor", {
        init: function (options) {
            var editor = options.editor;

            //Click action for F button.
            editor.querySelector("#f-degree-btn").addEventListener("click", function () {
                // Creates a custom event that notifies the widget about a change in the value of a property
                var event = new CustomEvent("updateProperty", {
                    detail: {
                        value: options.propertyValue = "F",
                        name: options.propertyName
                    }
                });
                editor.dispatchEvent(event);
            });

            //Click action for C button.
            editor.querySelector("#c-degree-btn").addEventListener("click", function () {
                // Creates a custom event that notifies the widget about a change in the value of a property
                var event = new CustomEvent("updateProperty", {
                    detail: {
                        value: options.propertyValue = "C",
                        name: options.propertyName
                    }
                });
                editor.dispatchEvent(event);
            });

            //Click action for K button.
            editor.querySelector("#k-degree-btn").addEventListener("click", function () {
                // Creates a custom event that notifies the widget about a change in the value of a property
                var event = new CustomEvent("updateProperty", {
                    detail: {
                        value: options.propertyValue = "K",
                        name: options.propertyName
                    }
                });
                editor.dispatchEvent(event);
            });

        }    
    });
})();
