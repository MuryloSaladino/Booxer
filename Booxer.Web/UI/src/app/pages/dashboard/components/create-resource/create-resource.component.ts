import { Component, EventEmitter, inject, Input, OnInit, Output, signal } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { DialogModule } from "primeng/dialog";
import { ResourceService } from "../../../../core/services/resource.service";
import { InputTextModule } from "primeng/inputtext";
import { DropdownModule } from 'primeng/dropdown';
import { Category } from "../../../../core/types/category.entity";
import { Resource } from "../../../../core/types/resource.entity";

@Component({
    selector: "create-resource",
    templateUrl: "./create-resource.component.html",
    styleUrl: "./create-resource.component.css",
    standalone: true,
    imports: [
        ReactiveFormsModule,
        DialogModule,
        ButtonModule,
        InputTextModule,
        DropdownModule,
    ],
})
export class CreateResourceComponent {

    @Input({ required: true }) category!: Category;
    @Output() onCreation = new EventEmitter<Resource>();

    readonly resourceService = inject(ResourceService);

    form: FormGroup;
    visible = false;

    constructor(private fb: FormBuilder) {
        this.form = fb.group({
            name: [null, Validators.required]
        })
    }

    async create() {
        const resource = await this.resourceService.create({
            ...this.form.value,
            categoryId: this.category.id,
        });
        this.onCreation.emit(resource);
        this.visible = false;
    }
}
