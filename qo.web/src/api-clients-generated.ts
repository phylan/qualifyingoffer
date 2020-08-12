/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.7.0.0 (NJsonSchema v10.1.24.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse, CancelToken } from 'axios';

export class QualifyingOfferClient {
    private instance: AxiosInstance;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, instance?: AxiosInstance) {
        this.instance = instance ? instance : axios.create();
        this.baseUrl = baseUrl ? baseUrl : "https://localhost:44310";
    }

    get(  cancelToken?: CancelToken | undefined): Promise<QualifyingOfferViewModel> {
        let url_ = this.baseUrl + "/api/QualifyingOffer";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <AxiosRequestConfig>{
            method: "GET",
            url: url_,
            headers: {
                "Accept": "application/json"
            },
            cancelToken
        };

        return this.instance.request(options_).catch((_error: any) => {
            if (isAxiosError(_error) && _error.response) {
                return _error.response;
            } else {
                throw _error;
            }
        }).then((_response: AxiosResponse) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: AxiosResponse): Promise<QualifyingOfferViewModel> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && typeof response.headers === "object") {
            for (let k in response.headers) {
                if (response.headers.hasOwnProperty(k)) {
                    _headers[k] = response.headers[k];
                }
            }
        }
        if (status === 200) {
            const _responseText = response.data;
            let result200: any = null;
            let resultData200  = _responseText;
            result200 = QualifyingOfferViewModel.fromJS(resultData200);
            return result200;
        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
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

function isAxiosError(obj: any | undefined): obj is AxiosError {
    return obj && obj.isAxiosError === true;
}