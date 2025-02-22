import { Component } from '@angular/core';
import { ApiService } from '../api/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  items: string[] = [];
  showList: boolean = false;
  title = 'test-app';

  constructor(private apiService: ApiService) {}

  onButtonClick() {
    this.apiService.buttonClicked().subscribe(response => {
      console.log('Response:', response);
    }, error => {
      console.error('Error:', error);
    });
  }

  loadItems() {
    this.apiService.showItemList().subscribe(items => {
      this.items = items;
      console.log('Items:', this.items);
    }, error => {
      console.error('Error loading items:', error);
    });
  }
  toggleList() {
    this.showList = !this.showList;
    if (this.showList && this.items.length === 0) {
      this.loadItems();
    }
  }
}
