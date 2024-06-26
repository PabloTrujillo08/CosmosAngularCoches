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
      },
      error: (e) => console.error(e)
    });
  }

  createNew() {
    this.selectedItem = {};
  }

  edit(item: any) {
    this.selectedItem = { ...item };
  }

  delete(id: string, data: any) {
    this.carService.delete(id, data).subscribe({
      next: () => {
        this.items = this.items.filter(item => item.id !== id);
      },
      error: (e) => console.error(e)
    });
  }

  save() {
    if (this.selectedItem.id) {
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

      this.selectedItem.id = "0";
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


  title = 'angularapicarscosmosdb.client';
}
