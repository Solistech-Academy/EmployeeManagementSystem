import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
	selector: 'app-confirmation-dialog',
	templateUrl: './confirmation-dialog.component.html',
	styleUrl: './confirmation-dialog.component.css',
})
export class ConfirmationDialogComponent {
	title: string;
	message: string;
	constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
		this.title = data.title;
		this.message = data.message;
	}

	confirm(): void {
		this.dialogRef.close(true);
	}

	cancel(): void {
		this.dialogRef.close(false);
	}
}
