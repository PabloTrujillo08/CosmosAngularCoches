import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CarsService } from './Services/cars.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {


  constructor(private http: HttpClient, private carService: CarsService) { }

  items: any[] = [];
  selectedItem: any = null;


  ngOnInit() {
    this.retrieveItems();
  }

  retrieveItems() {
    this.carService.getAll().subscribe({
      next: (data) => {
        this.items = data;
        console.log(data, "data")
      },
      error: (e) => console.error(e)
    });
  }

  createNew() {
    this.selectedItem = {};
  }

  edit(item: any) {
    console.log(item, "item")
    this.selectedItem = { ...item };
  }

  delete(id: number, data: any) {
    console.log(id, "id")
    console.log(data, "data")
    return
    this.carService.delete(id, data).subscribe({
      next: () => {
        this.items = this.items.filter(item => item.id !== id);
      },
      error: (e) => console.error(e)
    });
  }

  save() {
    if (this.selectedItem.id) {

      console.log(this.selectedItem, "selectedItem")
      this.carService.update(this.selectedItem.id, this.selectedItem).subscribe({
        next: () => {
          const index = this.items.findIndex(item => item.id === this.selectedItem.id);
          if (index !== -1) {
            this.items[index] = this.selectedItem;
          }
          this.selectedItem = null;
        },
        error: (e) => console.error(e)
      });
    } else {
      this.carService.create(this.selectedItem).subscribe({
        next: (newItem) => {
          this.items.push(newItem);
          this.selectedItem = null;
        },
        error: (e) => console.error(e)
      });
    }
  }

  cancel() {
    this.selectedItem = null;
  }

  trackById(index: number, item: any): any {
    return item.id;
  }

  title = 'angularapicarscosmosdb.client';
}
