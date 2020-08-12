/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.7.0.0 (NJsonSchema v10.1.24.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class QualifyingOfferClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "https://localhost:44310";
    }

    get(): Promise<QualifyingOfferViewModel> {
        let url_ = this.baseUrl + "/api/QualifyingOffer";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<QualifyingOfferViewModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = QualifyingOfferViewModel.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<QualifyingOfferViewModel>(<any>null);
    }
}

export class QualifyingOfferViewModel implements IQualifyingOfferViewModel {
    amount?: number;
    includedPlayers?: Player[] | undefined;

    constructor(data?: IQualifyingOfferViewModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.amount = _data["amount"];
            if (Array.isArray(_data["includedPlayers"])) {
                this.includedPlayers = [] as any;
                for (let item of _data["includedPlayers"])
                    this.includedPlayers!.push(Player.fromJS(item));
            }
        }
    }

    static fromJS(data: any): QualifyingOfferViewModel {
        data = typeof data === 'object' ? data : {};
        let result = new QualifyingOfferViewModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["amount"] = this.amount;
        if (Array.isArray(this.includedPlayers)) {
            data["includedPlayers"] = [];
            for (let item of this.includedPlayers)
                data["includedPlayers"].push(item.toJSON());
        }
        return data; 
    }
}

export interface IQualifyingOfferViewModel {
    amount?: number;
    includedPlayers?: Player[] | undefined;
}

export class Player implements IPlayer {
    name?: string | undefined;
    rawSalary?: string | undefined;
    year?: number | undefined;
    level?: string | undefined;
    salary?: number | undefined;

    constructor(data?: IPlayer) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.rawSalary = _data["rawSalary"];
            this.year = _data["year"];
            this.level = _data["level"];
            this.salary = _data["salary"];
        }
    }

    static fromJS(data: any): Player {
        data = typeof data === 'object' ? data : {};
        let result = new Player();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["rawSalary"] = this.rawSalary;
        data["year"] = this.year;
        data["level"] = this.level;
        data["salary"] = this.salary;
        return data; 
    }
}

export interface IPlayer {
    name?: string | undefined;
    rawSalary?: string | undefined;
    year?: number | undefined;
    level?: string | undefined;
    salary?: number | undefined;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}