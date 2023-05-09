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
    }

});