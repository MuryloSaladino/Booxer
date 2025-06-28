import { Component, inject, Input, OnInit, signal } from "@angular/core";
import { Resource } from "../../../../core/types/resource.entity";
import { ResourceService } from "../../../../core/services/resource.service";
import { Category } from "../../../../core/types/category.entity";
import { ButtonModule } from "primeng/button";
import { AuthService } from "../../../../core/services/auth.service";
import { CreateResourceComponent } from "../create-resource/create-resource.component";
import { RouterModule } from "@angular/router";

@Component({
    selector: "resource-list",
    templateUrl: "./resource-list.component.html",
    styleUrl: "./resource-list.component.css",
    standalone: true,
    imports: [
        ButtonModule,
        CreateResourceComponent,
        RouterModule,
    ],
})
export class ResourceListComponent implements OnInit {

    @Input({ required: true }) category!: Category;

    readonly auth = inject(AuthService);
    readonly resourceService = inject(ResourceService);
    readonly resources = signal<Resource[]>([]);

    async ngOnInit() {
        await this.fetchResources();
    }

    async fetchResources() {
        const response = await this.resourceService.getAll({
            categoryId: this.category.id,
        });
        this.resources.set(response);
    }

    appendResource(resource: Resource) {
        this.resources.update(prev => [...prev, resource]);
    }
}
