import { environment } from '../../../environments/environment';

export class Constants {
    public readonly API_URL = environment.apiUrl;
    public readonly GRID_PAGE_COUNT=5;
    public readonly GRID_PAGE_SIZE = 20;
}
