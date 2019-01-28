var VR_KEY = "isVr";
export function getUrl(route) {
    var routes = route.snapshot.pathFromRoot;
    var url = "";
    routes.forEach(function (item) {
        url += (item.url.length > 0 ? "/" + item.url[0].path : "");
    });
    return url;
}
export function getGeoLocation(http) {
    return http.get("https://api.ipdata.co/").map(function (x) {
        var item = {
            city: x.city,
            countryCode: x.country_code.toLowerCase(),
            countryName: x.country_name,
            ip: x.ip,
            latitude: x.latitude,
            longitude: x.longitude,
            regionCode: x.region_code,
            regionName: x.region,
            timeZone: x.time_zone,
            zipcode: x.postal
        };
        return item;
    });
}
export function getVRoot() {
    return window.getParameterByName("_vr") || window.getSessionParam(VR_KEY);
}
export function setVRoot(vRoot) {
    window.setSessionParam(VR_KEY, vRoot);
}
export function clearVRoot() {
    window.clearSessionParam(VR_KEY);
}
//# sourceMappingURL=http-utils.js.map