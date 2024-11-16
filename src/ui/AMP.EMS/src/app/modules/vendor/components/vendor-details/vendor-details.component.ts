import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService, VendorService } from '@core/services';
import { Vendor } from '@shared/models';
import { VendorType } from '@shared/models/vendor-type.model';
import { Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-vendor-details',
  templateUrl: './vendor-details.component.html',
  styleUrl: './vendor-details.component.scss'
})
export class VendorDetailsComponent implements OnInit {
  vendor$: Observable<Vendor> = new Observable<Vendor>();
  vendorTypes$: Observable<VendorType[]> = new Observable<VendorType[]>();

  constructor(private vendorService: VendorService, private lookupService: LookupService, private route: ActivatedRoute, private router: Router) {

  }

  ngOnInit(): void {
    this.vendor$ = this.loadVendor();
    this.vendorTypes$ = this.lookupService.getAll('vendortype');
  }

  loadVendor = () => {
    const vendorId = this.route.snapshot.paramMap.get("vendorId");
    if (!vendorId) return of<Vendor>({});

    return this.vendorService.get(vendorId);
  }

  save = (vendor: Vendor) => {
    if (vendor.name?.trim() && vendor.description?.trim() && vendor.address?.trim() && vendor.contactInformation?.trim()) {
      if (vendor.id) {
        this.vendor$ = this.vendorService.update(vendor)
          .pipe(
            switchMap(() => this.loadVendor()));
      }
      else {
        this.vendor$ = this.vendorService.add(vendor)
          .pipe(
            tap(vendor => {
              this.router.navigate(['vendors', vendor.id, 'edit'])
            }));
      }
    }
  }
}
