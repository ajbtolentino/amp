import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Event } from './event';

@Injectable()
export class EventService {
    eventNames: string[] = [
        "Bamboo Watch",
        "Black Watch",
        "Blue Band",
        "Blue T-Shirt",
        "Bracelet",
        "Brown Purse",
        "Chakra Bracelet",
        "Galaxy Earrings",
        "Game Controller",
        "Gaming Set",
        "Gold Phone Case",
        "Green Earbuds",
        "Green T-Shirt",
        "Grey T-Shirt",
        "Headphones",
        "Light Green T-Shirt",
        "Lime Band",
        "Mini Speakers",
        "Painted Phone Case",
        "Pink Band",
        "Pink Purse",
        "Purple Band",
        "Purple Gemstone Necklace",
        "Purple T-Shirt",
        "Shoes",
        "Sneakers",
        "Teal T-Shirt",
        "Yellow Earbuds",
        "Yoga Mat",
        "Yoga Set",
    ];

    constructor(private http: HttpClient) { }

    getProductsSmall() {
        return this.http.get<any>('assets/products-small.json')
            .toPromise()
            .then(res => <Event[]>res.data)
            .then(data => { return data; });
    }

    getEvents() {
        return this.http.get<any>('assets/events.json')
            .toPromise()
            .then(res => <Event[]>res.data)
            .then(data => { return data; });
    }

    getProductsWithOrdersSmall() {
        return this.http.get<any>('assets/products-orders-small.json')
            .toPromise()
            .then(res => <Event[]>res.data)
            .then(data => { return data; });
    }

    generateEvent(): Event {
        const event: Event = {
            id: this.generateId(),
            name: this.generateName(),
            description: "Event Description"
        };

        return event;
    }

    generateId() {
        let text = "";
        let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < 5; i++) {
            text += possible.charAt(Math.floor(Math.random() * possible.length));
        }

        return text;
    }

    generateName() {
        return this.eventNames[Math.floor(Math.random() * Math.floor(30))];
    }
}