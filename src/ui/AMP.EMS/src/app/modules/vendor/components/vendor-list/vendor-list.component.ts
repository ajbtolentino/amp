import { Component, OnInit } from '@angular/core';
import { LookupService, VendorService } from '@core/services';
import { Vendor } from '@shared/models';
import { map, Observable, switchMap } from 'rxjs';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrl: './vendor-list.component.scss'
})
export class VendorListComponent implements OnInit {
  vendors$: Observable<Vendor[]> = new Observable<Vendor[]>();

  constructor(private vendorService: VendorService, private lookupService: LookupService) {

  }

  ngOnInit(): void {
    this.vendors$ = this.loadVendors();
  }

  loadVendors = (): Observable<Vendor[]> => {
    return this.vendorService.getAll()
      .pipe(
        switchMap(vendors => this.loadVendorTypes(vendors))
      );
  }

  loadVendorTypes = (vendors: Vendor[]): Observable<Vendor[]> => {
    return this.lookupService.getByIds('vendortype', vendors.map(_ => _.vendorTypeId!))
      .pipe(map(vendorTypes => vendors.map(vendor => ({
        ...vendor,
        vendorType: vendorTypes.find(_ => _.id === vendor.vendorTypeId)
      }))))
  }
}
