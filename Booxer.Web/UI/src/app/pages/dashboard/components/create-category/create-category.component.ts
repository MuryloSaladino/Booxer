import { Component, EventEmitter, inject, Input, Output } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { DialogModule } from "primeng/dialog";
import { InputTextModule } from "primeng/inputtext";
import { DropdownModule } from 'primeng/dropdown';
import { Category } from "../../../../core/types/category.entity";
import { CategoryService } from "../../../../core/services/category.service";

@Component({
    selector: "create-category",
    templateUrl: "./create-category.component.html",
    styleUrl: "./create-category.component.css",
    standalone: true,
    imports: [
        ReactiveFormsModule,
        DialogModule,
        ButtonModule,
        InputTextModule,
        DropdownModule,
    ],
})
export class CreateCategoryComponent {

    @Output() onCreation = new EventEmitter<Category>();

    readonly categoryService = inject(CategoryService);

    form: FormGroup;
    visible = false;

    constructor(private fb: FormBuilder) {
        this.form = fb.group({
            name: [null, Validators.required]
        })
    }

    async create() {
        const category = await this.categoryService.create({
            ...this.form.value,
        }, { errorFeedback: true, successFeedback: {
            message: "Success!",
            details: `New category created!`
        }});
        this.onCreation.emit(category);
        this.visible = false;
    }
}
