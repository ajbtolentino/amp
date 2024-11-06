import { Injectable } from "@angular/core";
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
import { MenuItem } from "primeng/api";
import { BehaviorSubject, filter } from "rxjs";

@Injectable({
    providedIn: 'root',
})
export class BreadcrumbService {
    static readonly ROUTE_DATA_BREADCRUMB = 'breadcrumb';

    private readonly _breadcrumbs$ = new BehaviorSubject<MenuItem[]>([]);

    readonly breadcrumbs$ = this._breadcrumbs$.asObservable();


    constructor(private router: Router, private activatedRoute: ActivatedRoute) {
        this.router.events.pipe(
            filter(event => event instanceof NavigationEnd)
        ).subscribe(() => {
            const breadcrumbs = this.createBreadcrumbs(this.activatedRoute.root);

            this._breadcrumbs$.next(breadcrumbs);
        });
    }

    private createBreadcrumbs(route: ActivatedRoute, url: string = '', breadcrumbs: Array<MenuItem> = []): Array<MenuItem> {
        const children: ActivatedRoute[] = route.children;

        if (!children.length) {
            return breadcrumbs;
        }

        for (const child of children) {
            const routeURL: string = child.snapshot.url.map(segment => segment.path).join('/');
            if (routeURL !== '') {
                url += `/${routeURL}`;
            }

            const label = child.snapshot.data[BreadcrumbService.ROUTE_DATA_BREADCRUMB];
            if (label) {
                if (child.snapshot.data['url']) url = child.snapshot.data['url'];
                breadcrumbs.push({ label, url, target: '_self' });
            }

            return this.createBreadcrumbs(child, url, breadcrumbs);
        }

        return breadcrumbs;
    }
}