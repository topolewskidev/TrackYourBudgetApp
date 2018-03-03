import { Injectable } from '@angular/core';
import { ToastrService, IndividualConfig } from 'ngx-toastr';

@Injectable()
export class AlertService {
    private readonly options: Partial<IndividualConfig> = {
        tapToDismiss: true,
        closeButton: false,
        progressBar: true,
        positionClass: 'toast-top-full-width'
    };

    constructor(private toastrService: ToastrService) {
    }

    success(message: string) {
        this.toastrService.success(message, "Sukces!", this.options);
    }

    error(message: string) {
        this.toastrService.error(message, "Wystąpił błąd!", this.options);
    }
}