mergeInto(LibraryManager.library, {
    
    ShowInterstitialAdvertising: function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                // some action after close
                    console.log("-----Ad was closed-----");
                },
                onError: function(error) {
                // some action on error
                }
            }
        })
    },

    Rate: function () {
        ysdk.feedback.canReview()
            .then(({ value, reason }) => {
                if (value) {
                    ysdk.feedback.requestReview()
                        .then(({ feedbackSent }) => {
                            console.log(feedbackSent);
                        })
                } else {
                    console.log(reason)
                }
            })
    }

});