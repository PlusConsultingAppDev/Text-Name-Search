import { HttpHeaders } from '@angular/common/http';
import { getPortal } from '@iframework/config';
export function getRequest(type, userName, password, token, requestDetails) {
    var request = {
        request: {
            header: {
                type: type,
                username: userName,
                password: password,
                token: token,
                portal: getPortal(),
            },
            requestDetails: requestDetails
        }
    };
    return request;
}
export function mapResponse(response) {
    return response.map(function (res) {
        return res.response || res.Response;
    });
}
export function getRequestOptions() {
    return { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
}
//# sourceMappingURL=request-utils.js.map