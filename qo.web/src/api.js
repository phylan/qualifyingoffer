import { QualifyingOfferClient } from './api-clients-generated.ts'

import axios from 'axios'

const axiosInstance = axios.create()

export class ApiClient {
    constructor(baseUrl, instance) {
        this.qualifyingOffers = new QualifyingOfferClient(baseUrl, instance)
    }
}

export const Api = new ApiClient(process.env.VUE_APP_API_URL, axiosInstance)