import { Component, inject, signal } from "@angular/core";
import { CategoryService } from "../../core/services/category.service";
import { Category } from "../../core/types/category.entity";
import { ResourceListComponent } from "./components/resource-list/resource-list.component";
import { SearchContainerComponent } from "./components/search-container/search-container.component";
import { DividerModule } from 'primeng/divider';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    standalone: true,
    imports: [
        ResourceListComponent,
        SearchContainerComponent,
        DividerModule,
    ]
})
export class DashboardComponent {

    readonly categoryService = inject(CategoryService);
    readonly categories = signal<Category[]>([]);

    constructor() {
        this.updateCategories();
    }

    async updateCategories() {
        const response = await this.categoryService.getAll();
        this.categories.set(response);
    }
}
