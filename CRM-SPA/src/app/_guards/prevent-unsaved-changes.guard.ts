import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { CoworkerEditComponent } from '../coworkers_folder/coworker-edit/coworker-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<CoworkerEditComponent> {
    canDeactivate(component: CoworkerEditComponent) {
        if (component.editForm.dirty) {
            return confirm('Are your sure you want to continue? Any unsaved changes will be lost');
        }
        return true;
    }
}
