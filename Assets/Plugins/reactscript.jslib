mergeInto(LibraryManager.library, {

  TurbineState: function (x) {
    window.dispatchReactUnityEvent("TurbineState", x);
  },

});