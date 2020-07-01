var browserInterop = browserInterop || {};

browserInterop.showAlert = function (message) {
    alert(message);
};

browserInterop.showPrompt = function (message, defaultValue) {
    return prompt(message, defaultValue);
};

browserInterop.showConfirm = function (message, defaultValue) {
    return confirm(message, defaultValue);
};

browserInterop.consoleTable = function (obj) {
    console.table(obj);
};

browserInterop.focusElement = function (element) {
    element.focus();
};

browserInterop.focusElementById = function (id) {
    var element = document.getElementById(id);
    if (element) {
        element.focus();
    }
};

browserInterop.get = function (storeName, key) {
    return window[storeName][key];
};

browserInterop.set = function (storeName, key, value) {
    window[storeName][key] = value;
};

browserInterop.delete = function (storeName, key) {
    return delete window[storeName][key];
};

browserInterop.addMetaTag = function (attribute, value, content) {
    var metaTag = document.querySelector(`meta[${attribute}="${value}"]`)
    if (metaTag) {
        metaTag.setAttribute('content', content);
    } else {
        var meta = document.createElement('meta');
        meta.setAttribute(attribute, value);
        meta.setAttribute('content', content);
        document.getElementsByTagName('head')[0].appendChild(meta);
    }
};

browserInterop.removeMetaTag = function (attribute, value) {
    var metaTag = document.querySelector(`meta[${attribute}="${value}"]`)
    if (metaTag) {
        metaTag.remove();
    }
};

browserInterop.setPageTitle = function (title) {
    return document.title = title;
};
