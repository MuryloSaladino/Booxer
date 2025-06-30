import { Component, inject, OnInit, signal } from "@angular/core";
import { CategoryService } from "../../core/services/category.service";
import { Category } from "../../core/types/category.entity";
import { ResourceListComponent } from "./components/resource-list/resource-list.component";
import { SearchContainerComponent } from "./components/search-container/search-container.component";
import { DividerModule } from 'primeng/divider';
import { CreateCategoryComponent } from "./components/create-category/create-category.component";

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    standalone: true,
    imports: [
        ResourceListComponent,
        SearchContainerComponent,
        DividerModule,
        CreateCategoryComponent,
    ]
})
export class DashboardComponent implements OnInit {

    readonly categoryService = inject(CategoryService);
    readonly categories = signal<Category[]>([]);

    async ngOnInit() {
        const response = await this.categoryService.getAll();
        this.categories.set(response);
    }

    appendCategory(category: Category) {
        this.categories.update(prev => [...prev, category]);
    }
}
