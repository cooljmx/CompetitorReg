using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.PositionModels
{
    public class PositionListModel : CommonListModel<PositionModel>
    {
        public PositionListModel(ISessionHelper sessionHelper) : base (sessionHelper)
        {
        }

        public override void ReloadData()
        {
            Data.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Position>().List();
                foreach (var position in query)
                {
                    Data.Add(new PositionModel
                    {
                        Id = position.Id,
                        Name = position.Name
                    });
                }
            }
        }

        public override void ReloadFocusedRow()
        {
            if (FocusedRow == null) return;
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Position>(FocusedRow.Id);
                var itemGrid = Data.FirstOrDefault(x => x.Id == FocusedRow.Id);
                if (itemDb == null || itemGrid == null) return;

                var index = Data.IndexOf(itemGrid);
                Data[index] = new PositionModel
                {
                    Id = itemDb.Id,
                    Name = itemDb.Name
                };
                FocusedRow = Data[index];
            }
        }

        public override void ReloadAfterAdd(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Position>(id);
                var itemGrid = new PositionModel
                {
                    Id = itemDb.Id,
                    Name = itemDb.Name
                };
                Data.Add(itemGrid);
                FocusedRow = itemGrid;
            }
        }
    }
}
