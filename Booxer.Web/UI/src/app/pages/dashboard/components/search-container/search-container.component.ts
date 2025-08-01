import { Component, inject, signal } from "@angular/core";
import { InputTextModule } from "primeng/inputtext";
import { ResourceService } from "../../../../core/services/resource.service";
import { Resource } from "../../../../core/types/resource.entity";
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { animate, style, transition, trigger } from "@angular/animations";
import { ButtonModule } from "primeng/button";
import { RouterModule } from "@angular/router";

@Component({
    selector: 'search-container',
    templateUrl: './search-container.component.html',
    styleUrl: './search-container.component.css',
    standalone: true,
    imports: [
        InputTextModule,
        IconFieldModule,
        InputIconModule,
        ButtonModule,
        RouterModule,
    ],
})
export class SearchContainerComponent {

    readonly resourceService = inject(ResourceService);
    readonly resources = signal<Resource[] | null>(null);

    async updateResources(event: Event) {
        const input = event.target as HTMLInputElement;
        console.log(input.value)

        if(!input.value) {
            this.resources.set(null);
            return;
        }

        const response = await this.resourceService.getAll({
            search: input.value,
        });
        this.resources.set(response);
    }
}
