var browserInterop = browserInterop || {};

browserInterop.showAlert = function (message) {
    alert(message);
};

browserInterop.showPrompt = function (message, defaultValue) {
    return prompt(message, defaultValue);
};

const LogLevel = {
    Trace: 0,
    Debug: 1,
    Information: 2,
    Warning: 3,
    Error: 4
}

browserInterop.logLevel = 0;

browserInterop.logTrace = function (message, args) {
    optionalParams = optionalParams?.length ? optionalParams : undefined;
    if (this.logLevel <= LogLevel.Trace) {
        console.log(message, args);
    }
};

browserInterop.logDebug = function (message, args) {
    optionalParams = optionalParams?.length ? optionalParams : undefined;
    if (this.logLevel <= LogLevel.Debug) {
        console.log(message, args);
    }
};

browserInterop.logInfo = function (message, args) {
    optionalParams = optionalParams?.length ? optionalParams : undefined;
    if (this.logLevel <= LogLevel.Information) {
        console.log(message, args);
    }
};

browserInterop.logWarning = function (message, args) {
    optionalParams = optionalParams?.length ? optionalParams : undefined;
    if (this.logLevel <= LogLevel.Warning) {
        console.warn(message, args);
    }
};

browserInterop.logError = function (message, args) {
    optionalParams = optionalParams?.length ? optionalParams : undefined;
    if (this.logLevel <= LogLevel.Error) {
        console.error(message, args);
    }
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
